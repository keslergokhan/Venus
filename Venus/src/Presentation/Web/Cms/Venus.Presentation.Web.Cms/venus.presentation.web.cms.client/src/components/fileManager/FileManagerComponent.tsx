import type { JSX } from "react";
import { Button, Modal, ModalBody, ModalFooter, ModalHeader} from "flowbite-react";
import { useState } from "react";
import { CTextField } from "../commons";
import { IconOpenFolder } from "../commons/icons/OpenFolder";

export interface FileManagerComponentProps {
    selectFilenName:string
}

export const FileManagerComponent = (): JSX.Element => {
    const [openModal, setOpenModal] = useState<boolean>(false);
    const [fileName,setFileName] = useState<string>("Dosya Seç");
    return (
        <>
            <div className="w-[300px]">
                <CTextField value={fileName} onClick={()=>{setOpenModal(true)}} placeholder={fileName} Icon={<IconOpenFolder height={24} width={24} color="#104e64"></IconOpenFolder>}
                type="email" id="email" name="email" label="Kullan�c� Ad�" key="email"   ></CTextField>
            </div>
            
            <Modal show={openModal} position={"center"} onClose={() => setOpenModal(false)}>
                <ModalHeader>Small modal</ModalHeader>
                <ModalBody>
                    <div className="space-y-6 p-6">
                        <p className="text-base leading-relaxed text-gray-500 dark:text-gray-400">
                            With less than a month to go before the European Union enacts new consumer privacy laws for its citizens,
                            companies around the world are updating their terms of service agreements to comply.
                        </p>
                        <p className="text-base leading-relaxed text-gray-500 dark:text-gray-400">
                            The European Union�s General Data Protection Regulation (G.D.P.R.) goes into effect on May 25 and is meant
                            to ensure a common set of data rights in the European Union. It requires organizations to notify users as
                            soon as possible of high-risk data breaches that could personally affect them.
                        </p>
                    </div>
                </ModalBody>
                <ModalFooter>
                    <Button onClick={() => setOpenModal(false)}>I accept</Button>
                    <Button color="alternative" onClick={() => setOpenModal(false)}>
                        Decline
                    </Button>
                </ModalFooter>
            </Modal>
        </>
    );
}